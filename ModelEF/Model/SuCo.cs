namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuCo")]
    public partial class SuCo
    {
        [Key]
        [StringLength(10)]
        public string MaSC { get; set; }

        [StringLength(13)]
        public string MaND { get; set; }

        [StringLength(5)]
        public string MaPMT { get; set; }

        [StringLength(5)]
        public string MaMT { get; set; }

        [Column("SuCo")]
        [Required]
        [StringLength(50)]
        public string SuCo1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBC { get; set; }

        public TimeSpan? GioBC { get; set; }

        public virtual MayTinh MayTinh { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
