using Bookify.Application.Abstraction;
using Bookify.Application.Abstraction.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.GetBooking
{
    internal sealed class GetbookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetbookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }



        public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string sql =""""""
                SELECT 
                    id AS Id,
                    apartment_Id  AS ApartmentId,
                    user_id As UserId,
                    sttaus As Status,
                    price_for_period_amount As PriceAmount
                FROM bookings
                WHERE id = @BookingId
                """""";

            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
                sql,
                new
                {
                    request.bookingId
                });

            return Result.Success(booking);   
        
        }
    }
}
