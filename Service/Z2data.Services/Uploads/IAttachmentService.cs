using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;

namespace Z2data.Services.Uploads
{
    public interface IAttachmentService
    {
        Task<bool> RemoveAttachment(ObjectId attachmentId);
        Task<bool> UpdateAttachment(Attachment attachmenItem);
        Task<bool> AddAttachment(Attachment attachmenItem);
    }
}
