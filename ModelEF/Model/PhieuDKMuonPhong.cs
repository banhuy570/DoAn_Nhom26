namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDKMuonPhong")]
    public partial class PhieuDKMuonPhong
    {
        [Key]
        [StringLength(10)]
        public string MaDK { get; set; }

        [StringLength(13)]
        public string MaND { get; set; }

        [StringLength(5)]
        public string MaPMT { get; set; }

        public int? SLSV { get; set; }

        [StringLength(50)]
        public string TenPMT { get; set; }

        [StringLength(50)]
        public string LyDo { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySD { get; set; }

        public int TietBD { get; set; }

        public int TietKT { get; set; }

        public bool? TinhTrang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual PhongMay PhongMay { get; set; }
    }
}
