using CaseEptera.Reservation.Application.Features.Reservation.Queries;
using CaseEptera.Reservation.Application.Models;
using CaseEptera.Reservation.Domain.Abstract;
using CaseEptera.Reservation.Infrastructure.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Features.RoomType.Queries
{
    public class GetRoomTypeQuery : IRequest<ActionResponse<List<RoomTypeDto>>>
    {
        public int RoomCount { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Child1 { get; set; }
        public int Child2 { get; set; }
        public int Child3 { get; set; }
    }

    public class GetRoomTypeQueryHandler : IRequestHandler<GetRoomTypeQuery, ActionResponse<List<RoomTypeDto>>>
    {
        private readonly IUnitOfWork _uow;
        public GetRoomTypeQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ActionResponse<List<RoomTypeDto>>> Handle(GetRoomTypeQuery request, CancellationToken cancellationToken)
        {
            var response = ActionResponse<List<RoomTypeDto>>.Success(200);

            try
            {

                string query = @"WITH AvailableRoom AS (
                        SELECT
                            ot.recId AS roomTypeId,
                            ot.adult,
                            ot.child,
                            ot.roomtypename,
                            ot.roomcount,
                            kb.startdate,
                            kb.enddate,
                            kb.AvailableRoomCount
                        FROM
                            roomquota kb
                        INNER JOIN roomtype ot ON kb.RoomTypeId = ot.recId
                        LEFT JOIN reservationinfo r ON ot.recId = r.RoomTypeId
                            AND r.checkindate <= @xCheckOutDate
                            AND r.checkoutdate >= @xCheckInDate
                        WHERE
                            kb.startdate <= @xCheckOutDate
                            AND kb.enddate >= @xCheckInDate
                        GROUP BY
                            kb.recId, ot.adult, ot.child, ot.roomtypename, ot.roomcount, kb.startdate, kb.enddate, kb.AvailableRoomCount, ot.recId
                    )
                    SELECT
                        mo.roomTypeId,
                        mo.roomtypename,
                        mo.roomcount,
                        mo.availableRoomCount
                    FROM
                        AvailableRoom mo
                    WHERE
                        ";

                if(request.RoomCount > 0)
                {
                    query += " mo.availableRoomCount >= @xRoomCount ";
                }
                else
                {
                    query += " mo.availableRoomCount > 0 ";
                }

                if(request.Adult > 0)
                {
                    query += " AND mo.adult >= @xAdult ";
                }
                else
                {
                    query += " AND mo.adult > 0 ";
                }
                if(request.Child >= 0)
                {
                    query += " AND mo.child >= @xChild ";
                }

                response.Data = _uow.Query<RoomTypeDto>(query, new
                {
                    xCheckOutDate = request.CheckoutDate,
                    xCheckInDate = request.CheckinDate,
                    xRoomCount = request.RoomCount,
                    xAdult = request.Adult,
                    xChild = request.Child,
                    xChild1 = request.Child1,
                    xChild2 = request.Child2,
                    xChild3 = request.Child3
                }).ToList();

                response.IsSuccessful = true;
                
            }
            catch (Exception ex)
            {

                throw;
            }
            return response;
        }
    }
}
