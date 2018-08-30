using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Z2data.Core.Domain.Events;
using Z2data.Services.Uploads;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix("Importer")]
    public class ImporterController : ApiController
    {
        #region Fields
        private readonly IAttachmentService _attachmentItemService;
        #endregion

        #region Ctor
        public ImporterController(IAttachmentService attachmentItemService)
        {
            _attachmentItemService = attachmentItemService;
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

                    var filePath = HttpContext.Current.Server.MapPath("~/uploads/" + attachment.Id + attachment.Extension);
                    try
                    {
                        postedFile.SaveAs(filePath);
                        
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return atachments;

        }
        #endregion
    }
}
