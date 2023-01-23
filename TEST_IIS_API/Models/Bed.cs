using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEST_IIS_API.Models;

public partial class Bed
{
    [Key]
    public int? RowId { get; set; }

    public Guid? BedGuid { get; set; }

    public Guid? RoomId { get; set; }

    public string? BedNumber { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdeleted { get; set; }

    public Guid? Createdby { get; set; }

    public DateTime? Createddate { get; set; }

    public Guid? Modifiedby { get; set; }

    public DateTime? Modifieddate { get; set; }
}
