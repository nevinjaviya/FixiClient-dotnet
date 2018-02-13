using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  public class Attachment
  {
    public string BlobName { get; set; }

    public DateTimeOffset? Created { get; set; }

    public string FileName { get; set; }

    public string MimeType { get; set; }

    public DateTimeOffset? Modified { get; set; }

    public string Uri { get; set; }
  }
}