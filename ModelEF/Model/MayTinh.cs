namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MayTinh")]
    public partial class MayTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MayTinh()
        {
            SuCoes = new HashSet<SuCo>();
        }

        [Key]
        [StringLength(5)]
        public string MaMT { get; set; }

        [StringLength(5)]
        public string MaPMT { get; set; }

        [StringLength(50)]
        public string BanPhim { get; set; }

        [StringLength(50)]
        public string Chuot { get; set; }

        [StringLength(50)]
        public string ManHinh { get; set; }

        [StringLength(50)]
        public string ThungMay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamLD { get; set; }

        public bool TinhTrang { get; set; }

        public virtual PhongMay PhongMay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuCo> SuCoes { get; set; }
    }
}
