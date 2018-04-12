using ProjectPreparing.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPreparing.Project.Core.Repositories
{
    public interface IShoeRepository
    {
        List<ShoeViewModel> GetAll();
    }
}
