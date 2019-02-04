using System.Collections.Generic;
using VideoRentalStore.Models;

namespace VideoRentalStore.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}