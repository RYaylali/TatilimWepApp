﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.DataAccessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TDelete(Room entity)
        {
           _roomDal.Delete(entity);
        }

        public Room TGetByID(int id)
        {
            return _roomDal.GetByID(id);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public void TInsert(Room entity)
        {
           _roomDal.Insert(entity);
        }

        public void TUpdate(Room entity)
        {
            _roomDal.Update(entity);    
        }
    }
}