using ProjectPreparing.Project.Core.Repositories.Implementations;
using ProjectPreparing.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPreparing.Project.Core.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<CartViewModel> GetAll(string Id)
        {
           return this.cartRepository.GetAll( Id );
        }

        public void PostToCart(int Id, string Cookie)
        {
            this.cartRepository.PostToCart(Id, Cookie);
        }
    }
}
