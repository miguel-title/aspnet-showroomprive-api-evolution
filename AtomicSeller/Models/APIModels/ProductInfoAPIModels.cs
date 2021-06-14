﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicSeller.Models;
using AtomicCommonAPI.Models;

namespace AtomicProductAPI.Models
{

    /// ////////////////////////////////////////////////

        /*
    public class PutProductsInfoRequest
    {
        public Header Header { get; set; }
        public PutProductsInfoRequestData Request { get; set; }
    }
    */
    public class PutProductsInfoRequestData
    {
        public string Option { get; set; }
        public string LanguageCode { get; set; }
        public string StoreKey { get; set; }
        //public List<Product> Products { get; set; } // Pat 17/07/2019
        public List<WSProduct> Products { get; set; } // Pat 17/07/2019

    }
    public class WSProduct
    {
        //public Product Product { get; set; }
        //public List<AtomicProductAPI.Models.WSProductLot> ProductLots { get; set; }

    }

        public class WSProductLot
    {
        public int ProductLotID { get; set; }
        //public string SKU { get; set; }
        public int ProductID { get; set; }
        public string BestBeforeDate { get; set; }
        public string ExpirationDate { get; set; }
        public string StockEntryDate { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductLotID_Ext { get; set; }
        public string ProductLotKey { get; set; }
    }

    public class GetProductsInfoData
    {
        public string StoreKey { get; set; }
        public string SKU { get; set; }
        public string Option { get; set; }
        public string LanguageCode { get; set; }
        public string UpdatedFromTime { get; set; }
        public string Stock { get; set; }
        public string ProductID { get; set; }
    }



    public class PutProductsInfoData
    {
        public string StoreKey { get; set; }
        public string SKU { get; set; }
        public string ProductID { get; set; }
        public string StockValue { get; set; }
    }

    
    public class PutProductInfoResponse
    {
        public ResponseHeader Header { get; set; }
        public PutProductInfoData Response { get; set; }
    }


    public class PutProductInfoData
    {
        //List<Product> Products;

    }
    

}