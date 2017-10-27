﻿using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    // ReSharper disable once InconsistentNaming
    public interface IESImageRepository
    {
        void CreateESImage(ESImage image);
        ESImage GetESImage(long esimageId);
        void UpdateESIamge(ESImage newImage);
        void DeleteESImage(long esimageId);
    }
}