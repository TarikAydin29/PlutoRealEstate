using RealEstate.BLL.Abstract;
using RealEstate.DAL.Abstract;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            this.messageDAL = messageDAL;
        }
        public void TDelete(Message entity)
        {
            messageDAL.Delete(entity);
        }

        public Task<List<Message>> TGetAllAsync()
        {
            return messageDAL.GetAllAsync();
        }

        public Task<Message> TGetByIdAsync(Guid Id)
        {
            return messageDAL.GetByIdAsync(Id);
        }

        public Task<Message> TInsertAsync(Message entity)
        {
            return messageDAL.InsertAsync(entity);
        }

        public Task<int> TSaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> TUpdateAsync(Message entity)
        {
            return messageDAL.UpdateAsync(entity);
        }
    }
}
