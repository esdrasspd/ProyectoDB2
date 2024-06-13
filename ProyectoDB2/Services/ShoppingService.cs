using ProyectoDB2.Models;

namespace ProyectoDB2.Services
{
    public class ShoppingService
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void AddItem(CartItem item)
        {
            
            var existingItem = Items.FirstOrDefault(i => i.Referencia == item.Referencia);
            if (existingItem != null)
            {
                existingItem.Cantidad = item.Cantidad;
            }
            else
            {
                Items.Add(item);
            }
        }
    }
}
