using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSwagger.Attr
{
    /// <summary>
    /// FromFile
    /// </summary>
    public class FromFileAttribute: Attribute, IBindingSourceMetadata
    {
        /// <summary>
        /// 是指定 BindingSource 为 BindingSource.FormFile
        /// </summary>
        public BindingSource BindingSource => BindingSource.FormFile;
    }
}
