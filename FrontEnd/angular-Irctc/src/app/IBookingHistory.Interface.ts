export interface IBookingHistory{
    bookingId:number;
    train:string;
    coach:string;
    fromStation:string;
    toStation:string;
    count:number;
    total:number;
    bookingStatus:string;
}