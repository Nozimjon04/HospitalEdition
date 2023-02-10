using PharmacyEditon.Configurations;
using PharmacyEditon.IRepositories;
using PharmacyEditon.Models;

namespace PharmacyEditon.Repsotories
{
        public class MedicineRepository : IMedicineRepository
    {
        private readonly string path = DatabasePath.MEDICINE_PATH;
        public async Task<Medicine> CreateAsync(Medicine medicine)
        {
            string sr = $"{medicine.ID}|{medicine.Count}|{medicine.Name}|{medicine.Description}|{medicine.Price}|{medicine.CreatedAt}\n";
            File.AppendAllText(path,sr);
            return medicine;
            
        }

        public async Task<bool> DelateAsync(string name)
        {
            bool check=false;
            var medicines = (dynamic)GetAllAsync();
            File.WriteAllText(path,"");
            foreach(var medicine in medicines)
            {
                if(medicine.Name == name)
                {
                    check = true;
                    continue;
                }
                CreateAsync(medicine);
            }
            return check;
        }

        public async Task<List<Medicine>> GetAllAsync()
        {
            List<Medicine> list = new List<Medicine>();
            var read=File.ReadAllLines(path);
            foreach (var line in read)
            {
                var parts = line.Split("|");
                Medicine medicine= new Medicine();
                medicine.ID = int.Parse(parts[0]);
                medicine.Count = int.Parse(parts[1]);
                medicine.Name = parts[2];
                medicine.Description = parts[3];
                medicine.Price = decimal.Parse(parts[4]);
                medicine.CreatedAt = DateTime.Parse(parts[5]);
                list.Add(medicine);
            }
           return list;
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            Medicine medicine = new Medicine();
            var lines=File.ReadAllLines(path);
            foreach(var line in lines)
            {
                var parts = line.Split("|");
                
                if (int.Parse(parts[0]) == id)
                {
                    medicine.ID= int.Parse(parts[0]);
                    medicine.Count= int.Parse(parts[1]);
                    medicine.Name = parts[2];
                    medicine.Description = parts[3];
                    medicine.Description= parts[4];
                    medicine.CreatedAt= DateTime.Parse(parts[5]);
                    return medicine;
                }
            }
            return null;
           
        }

        public async Task<Medicine> UpdateAsync(Medicine medicine)
        {
            Medicine medicine1= new Medicine();
            var lines= File.ReadAllLines(path);
            foreach(var line in lines)
            {
                var parts = line.Split("|");
                if (medicine.ID == int.Parse(parts[0]))
                {
                    medicine1.ID = medicine.ID;
                    medicine1.Name = medicine.Name;
                    medicine1.Count = medicine.Count;
                    medicine1.Price = medicine.Price;
                    medicine1.Description= medicine.Description;
                    medicine1.CreatedAt = medicine.CreatedAt;
                    return medicine1;
                }
            }
            return null;
      
        }
    }
}
