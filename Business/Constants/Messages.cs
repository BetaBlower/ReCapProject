using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        #region ErrorMessages

        public static string CharacterError = "Minimum 2 karakter olmalıdır";
        public static string PriceError = "Günlük fiyat 0'dan büyük olmalıdır";
        public static string TimeError = "Zaman hatası";
        public static string LimitCarImageError = "Resim ekleme sınırına ulaşıldı";
        public static string CarImageCouldNotBeAdded = "araba resmi eklenemedi";
        #endregion

        #region SuccessMessages

        public static string Success = "İşlemininiz Başarıyla Tamamlanmıştır";

        public static string CarImageAdded = "araba resmi eklendi";





        #endregion

        #region InfoMessages

        #endregion
    }
}
