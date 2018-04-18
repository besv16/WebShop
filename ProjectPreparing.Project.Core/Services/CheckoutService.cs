using ProjectPreparing.Project.Core.Models;
using ProjectPreparing.Project.Core.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPreparing.Project.Core.Services
{
    public class CheckoutService
    {
        private CheckoutRepository checkoutRepository;

        public CheckoutService(CheckoutRepository checkoutRepository)
        {
            this.checkoutRepository = checkoutRepository;
        }

        public List<CheckoutViewModel> GetAll()
        {
            return this.checkoutRepository.GetAll();
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string City, int Zipcode, string cookie)
        {
            this.checkoutRepository.PostToOrder(Firstname, Lastname, Email, Phone, City, Zipcode, cookie);
        }
    }
}
