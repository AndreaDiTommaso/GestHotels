﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Commands.RoomType
{
    public class DeleteRoomTypeCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
