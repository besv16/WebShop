using ProjectPreparing.Project.Core.Models;
using ProjectPreparing.Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPreparing.Project.Core.Services
{
    public class ShoeService
    {
        private IShoeRepository shoeRepository;

        public ShoeService(IShoeRepository shoeRepository)
        {
            this.shoeRepository = shoeRepository;
        }

        public List<ShoeViewModel> GetAll()
        {
            return this.shoeRepository.GetAll();
        }
    }
}
