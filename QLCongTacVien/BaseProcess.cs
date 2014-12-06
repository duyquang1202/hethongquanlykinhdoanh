using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace QLCongTacVien
{
    public class BaseProcess
    {
        protected QLCongTacVienEntities DbContext;
        public BaseProcess()
        {

            DbContext = new QLKH();
        }
    }
    public class QLKH : QLCongTacVienEntities
    {
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var innerEx = e.InnerException;

                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                throw new Exception(innerEx.Message);
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();

                foreach (var entry in e.EntityValidationErrors)
                {
                    foreach (var error in entry.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("{0}-{1}-{2}",
                            entry.Entry.Entity,
                            error.PropertyName,
                            error.ErrorMessage
                            )
                        );
                    }
                }
                throw new Exception(sb.ToString());
            }
        }
    }
}