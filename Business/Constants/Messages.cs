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

        #endregion

        #region SuccessMessages

        public static string Success = "İşlemininiz Başarıyla Tamamlanmıştır";

        #endregion

        #region InfoMessages

        #endregion
    }
}
