﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Queries.Hotel;
using GestHotelsDomain.Repositories.Hotel;
using MediatR;
namespace GestHotelsDomain.Handlers.Hotel
{
    public class GetHotelListHandler : IRequestHandler<GetHotelListQuery, List<Entities.Hotel>>
    {
    
        private readonly IHotelRepository _hotelRepository;

        public GetHotelListHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Entities.Hotel>> Handle(GetHotelListQuery query, CancellationToken cancellationToken)
        {
            return await _hotelRepository.GetHotelListAsync();
        }
    }
}
