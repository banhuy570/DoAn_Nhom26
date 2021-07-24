namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThoiKhoaBieu")]
    public partial class ThoiKhoaBieu
    {
        [Key]
        [StringLength(15)]
        public string MaTKB { get; set; }

        [StringLength(13)]
        public string MaND { get; set; }

        [StringLength(5)]
        public string MaPMT { get; set; }

        public int HocKy { get; set; }

        [Required]
        [StringLength(100)]
        public string MonHoc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenGV { get; set; }

        public int Thu { get; set; }

        public int TuTiet { get; set; }

        public int DenTiet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBD { get; set; }

        public int SoLuongSV { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual PhongMay PhongMay { get; set; }
    }
}
