﻿using IRCTCModel.Models;
using Microsoft.EntityFrameworkCore;

namespace IRCTC.Repository.Context
{
    public class IrctcContext : DbContext
    { 

        public IrctcContext(DbContextOptions option) :base(option) 
        {
        }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TrainType> TrainType { get; set; }
        public DbSet<TrainStop> TrainStop { get; set; }
        public DbSet<TrainClass> TrainClass { get; set; }
        public DbSet<Train> Train { get; set; }
        public DbSet<Station> Station { get; set; }    
        public DbSet<SeatType> SeatType { get; set; }  
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Booking>  Booking { get; set; }
    }
}