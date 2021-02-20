using System.Collections.Generic;
using Services;

namespace Entities
{
    public class SerieRepository : IRepository<Serie>
    {
       private List<Serie> listSerie = new List<Serie>();

        public void Update(int id, Serie entitie)
        {
            listSerie[id - 1] = entitie;
        }

        public void Delete(int id)
        {
            listSerie[id - 1].Delete(); //Não remove a informação do vetor, apenas oculta.
        }

        public void Insert(Serie entitie)
        {
            listSerie.Add(entitie);
        }

        public List<Serie> List()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id - 1];
        }
    }
}