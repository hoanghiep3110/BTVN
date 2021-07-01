namespace BTVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Required(ErrorMessage = "ID không được để trống")]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Tiêu đề sách không được vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Title { get; set; }

        [StringLength(30,ErrorMessage = "Tên tác giả không được vượt quá 30 ký tự")]
        [Required(ErrorMessage = "Tên tác giả không được để trống")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(70)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        [StringLength(50)]
        public string ImageCover { get; set; }

        [Range(1000, 1000000, ErrorMessage = "Vui lòng nhập giá tiền trong khoản 1000đ đến 1000000đ")]
        [Required(ErrorMessage = "Giá tiền không được để trống")]
        public int? Price { get; set; }
    }
}
