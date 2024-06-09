using CaseEptera.Reservation.Application.Features.Reservation.Commands;
using CaseEptera.Reservation.Application.Models;
using CaseEptera.Reservation.Domain.Abstract;
using CaseEptera.Reservation.Infrastructure.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Features.Reservation.Queries
{
    public class GetReservationQuery : IRequest<ActionResponse<List<ReservationDto>>>
    {
    }
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, ActionResponse<List<ReservationDto>>>
    {
        private readonly IUnitOfWork _uow;

        public GetReservationQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ActionResponse<List<ReservationDto>>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var response = ActionResponse<List<ReservationDto>>.Success(200);

            string query = @"select
                                res.recId,
                                res.guestname,
                                res.checkindate,
                                res.checkoutdate,
                                res.adult,
                                res.child,
                                res.child1,
                                res.child2,
                                res.child3,
                                res.roomTypeId,
                                res.price,
                                room.roomtypename
                                from reservationinfo res
                                left join roomtype room on room.recId=res.roomTypeId
                                where res.deleted=0; ";

            response.Data = _uow.Query<ReservationDto>(query);
            response.StatusCode = 200;
            response.IsSuccessful = true;

            return response;
        }
    }
}
