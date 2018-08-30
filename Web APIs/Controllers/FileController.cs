using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using OfficeOpenXml;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;
using Z2data.Services.Locations;
using Z2data.Services.Uploads;
using Z2data.Data;
using Z2data.Services.EventCategories;
using Z2data.Services.Disasters;

namespace Z2data.Web.APIs.Controllers
{

    [RoutePrefix("File")]

    public class FileController : ApiController
    {
        #region Fields

        private readonly IAttachmentService _attachmentItemService;
        private readonly IAirportService _airportService;
        private readonly ISeaportService _seaportService;
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IDisasterHistoryService _disasterHistoryService;
        private readonly IParkService _parkService;
        private readonly IIndustryService _industryService;
        #endregion

        #region Ctor

        public FileController(IAttachmentService attachmentItemService, IAirportService airportService, ISeaportService seaportService, IEventCategoryService eventCategoryService, IDisasterHistoryService disasterHistoryService, IParkService parkService, IIndustryService industryService)
        {
            _attachmentItemService = attachmentItemService;
            _airportService = airportService;
            _seaportService = seaportService;
            _eventCategoryService = eventCategoryService;
            _disasterHistoryService = disasterHistoryService;
            _parkService = parkService;
            _industryService = industryService;
        }

        #endregion

        #region Methods

        public async Task<IList<Attachment>> Post()
        {
            var atachments = new List<Attachment>();
            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];

                    Attachment attachment = new Attachment
                    {
                        Extension = Path.GetExtension(postedFile.FileName),
                        Name = Path.GetFileName(postedFile.FileName)
                    };
                    await _attachmentItemService.AddAttachment(attachment);

                    var filePath =
                        HttpContext.Current.Server.MapPath("~/uploads/" + attachment.Id + attachment.Extension);
                    try
                    {
                        postedFile.SaveAs(filePath);
                        atachments.Add(attachment);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return atachments;

        }
        [Route("PostExcel")]
        [HttpPost]
        public async Task<int> PostExcel(ImportType type)
        {
            var httpRequest = HttpContext.Current.Request;
            int count = 0;
            if (httpRequest.Files.Count > 0)
            {
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];


                    var filePath = HttpContext.Current.Server.MapPath(Path.Combine("~/importers/", postedFile.FileName));
                    //determine if file exist
                    if (File.Exists(filePath))
                    {
                        //delete existing file
                        File.Delete(filePath);
                    }
                    postedFile.SaveAs(filePath);

                    FileInfo fileInfo = new FileInfo(filePath);

                    var package = new ExcelPackage(fileInfo);

                    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];

                    switch (type)
                    {
                        case ImportType.Airport:
                            var airports = workSheet.ToList<AirportMap>();
                            count = await _airportService.ImportAirports(airports);
                            break;
                        case ImportType.Seaport:
                            var seaports = workSheet.ToList<SeaportMap>();
                            count = await _seaportService.ImportSeaports(seaports);
                            break;
                        case ImportType.EventCategory:
                            var categories = workSheet.ToList<EventCategoryMap>();
                            count = await _eventCategoryService.ImportEventCategories(categories);
                            break;
                        case ImportType.Disaster:
                            var disaster = workSheet.ToList<DisasterHistoryMap>();
                            count = await _disasterHistoryService.ImportDisasters(disaster);
                            break;
                        case ImportType.Park:
                            var park = workSheet.ToList<ParkMap>();
                            count = await _parkService.ImportParks(park);
                            break;
                        case ImportType.Industry:
                            var industry = workSheet.ToList<IndustryMap>();
                            count = await _industryService.ImportIndustries(industry);
                            break;
                        case ImportType.ParkCompany:
                            var parkCompany = workSheet.ToList<ParkCompanyMap>();
                            count = await _parkService.ImportParkCompanies(parkCompany);
                            break;
                        case ImportType.ParkIndustry:
                            var parkIndustry = workSheet.ToList<ParkIndustryMap>();
                            count = await _parkService.ImportParkIndustries(parkIndustry);
                            break;
                    }
                }
            }
            return count;

        }
        #endregion
    }
}
