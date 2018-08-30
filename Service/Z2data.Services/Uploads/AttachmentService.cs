using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;

namespace Z2data.Services.Uploads
{
    public class AttachmentService: IAttachmentService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<Attachment> _attachmentRepositoryAsync;
        #endregion

        #region Ctor
        public AttachmentService(IMongoRepositoryAsync<Attachment> attachmentRepositoryAsync)
        {
            _attachmentRepositoryAsync = attachmentRepositoryAsync;
        }
        #endregion

        #region Methods
        public Task<bool> AddAttachment(Attachment attachmenItem)
        {
            if (attachmenItem == null)
                throw new ArgumentNullException(nameof(attachmenItem));

            return _attachmentRepositoryAsync.AddAsync(attachmenItem);
        }

        public Task<bool> UpdateAttachment(Attachment attachmenItem)
        {
            if (attachmenItem == null)
                throw new ArgumentNullException(nameof(attachmenItem));

            return _attachmentRepositoryAsync.UpdateAsync(attachmenItem);
        }

        public Task<bool> RemoveAttachment(ObjectId attachmentId)
        {
            if (attachmentId == null)
                throw new ArgumentNullException(nameof(attachmentId));

            return _attachmentRepositoryAsync.RemoveAsync(attachmentId);
        }
        #endregion
    }
}
