using ProjectPreparing.Project.Core.Models;
using ProjectPreparing.Project.Core.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPreparing.Project.Core.Services
{
    public class CheckoutService
    {
        private readonly CheckoutRepository checkoutRepository;
        private readonly CartRepository cartRepository;

        public CheckoutService(CheckoutRepository checkoutRepository, CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
            this.checkoutRepository = checkoutRepository;
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string City, int Zipcode, string cookie)
        {
            this.checkoutRepository.PostToOrder(Firstname, Lastname, Email, Phone, City, Zipcode, cookie);
        }
        
        public void DeleteCart(string cookie)
        {
            this.checkoutRepository.DeleteCart(cookie);
        }

        public CheckoutViewModel GetAll(string Id)
        {
            var cart = this.cartRepository.GetAll(Id);
            var checkoutModel = new CheckoutViewModel { Cart = cart };
            return checkoutModel;
        }
    }
}
