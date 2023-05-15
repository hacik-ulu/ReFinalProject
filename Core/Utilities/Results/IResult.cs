using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel void işlemleri için başlangıç.
    //İşlem sonucu.
    //Kullanıcıyı bilgilendirmek için son mesaj.

    public interface IResult
    {
        bool Succes { get; }
        string Message { get; }
    }
}
