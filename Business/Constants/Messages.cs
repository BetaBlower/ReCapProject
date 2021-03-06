using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserAlreadyExits = "Zaten çıkış yapıldı";
        public static string PasswordError = "Şifre hatalı";
        public static string AuthorizationDenied = "Yetkiniz yok";
        #endregion

        #region SuccessMessages
        public static string Success = "İşlemininiz Başarıyla Tamamlanmıştır";
        public static string CarImageAdded = "araba resmi eklendi";
        public static string UserRegistered = "Kayıt olma işlemi tamamlandı";
        public static string SuccessForLogin = "Giriş başarılı";
        public static string SuccessUserExits = "Çıkış yapıldı";
        public static string AccessTokenCreated = "Token oluşturuldu";


        #endregion

        #region InfoMessages

        #endregion
    }
}
