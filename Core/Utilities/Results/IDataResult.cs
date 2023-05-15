using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Bu interface mesaj , işlem sonucu ve data içersin.
    //Data -- Ürünler
    //<T> -- Ürün , Kategori Listesi olabilir.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
