using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebLibrarySystem.Models
{
    public class KitapTuru
    {
        [Key]  // id set as primary key
        public int Id { get; set; }
        [Required(ErrorMessage ="Kitap Tür Adı Boş Bırakılamaz!")] // Ad is required / Ad zorunlu alandir bos birakilamaz.
        [MaxLength(25)] // Ad can be max 25 characters / Ad maksimum 25 karakter olabilir.
        [DisplayName ("Kitap Türü Adı")] // Display name for Ad / Ad icin goruntulenecek isim
        public string Ad { get; set; }
        // Kitap turu ve adi tanimlandi ve id primary key olarak set edildi.


      
    }
}
