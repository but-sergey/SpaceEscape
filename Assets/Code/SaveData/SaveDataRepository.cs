using System.Data;
using System.IO;
using UnityEngine;

namespace RollABall
{
    public sealed class SaveDataRepository : ISaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.dat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(Transform player)
        {
            if(!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player.position,
                Name = "Sergey",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(Transform player)
        {
            var file = Path.Combine(_path, _fileName);
            if(!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);
        }
    }
}
