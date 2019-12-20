using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TepeGuvCase.WebUI.Tools
{
    public class MyCart
    {
        private Dictionary<int, CartItem> _sepet = new Dictionary<int, CartItem>();

        public List<CartItem> GetAllCartItem { get { return _sepet.Values.ToList(); } }

        public void Add(CartItem cartItem)
        {
            if (_sepet.ContainsKey(cartItem.ID))
            {
                _sepet[cartItem.ID].Amount += cartItem.Amount;
                return;
            }

            _sepet.Add(cartItem.ID, cartItem);
        }
        public void Update(int id, short amount)
        {
            if (_sepet.ContainsKey(id))
            {
                _sepet[id].Amount = amount;
            }
        }

        public void Delete(int id)
        {
            if (_sepet.ContainsKey(id))
            {
                _sepet.Remove(id);
            }
        }

        public int TotalAmount { get { return _sepet.Values.Sum(x => x.Amount); } }
    }
}