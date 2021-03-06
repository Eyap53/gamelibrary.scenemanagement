namespace GameLibrary.SceneManagement.Paths
{
	using UnityEngine;

	/// <summary>
	/// This class goes on a trigger which, when entered, sends the player to another Location.
	/// </summary>

	public class LocationExit : MonoBehaviour
	{
		[SerializeField] private SceneSO _locationToLoad = default;
		[SerializeField] private PathSO _leadsToPath = default;
		[SerializeField] private PathStorageSO _pathStorage = default; //This is where the last path taken will be stored

		[Header("Broadcasting on")]
		[SerializeField] private SceneLoadEventChannelSO _locationExitLoadChannel = default;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				if (_pathStorage != null)
					_pathStorage.lastPathTaken = _leadsToPath;

				_locationExitLoadChannel.RaiseEvent(_locationToLoad);
			}
		}
	}
}
