﻿namespace EmbeddedStock.Models
{
    public enum ComponentStatus
    {
        Available, 
        ReservedLoaner,
        ReservedAdmin,
        Loaned,
        Defect,
        Trashed,
        Lost,
        NeverReturned
    }
}