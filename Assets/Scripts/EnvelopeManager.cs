using System.IO;
using UnityEngine;

public class EnvelopeManager : MonoBehaviour
{
    [System.Serializable]
    private class LevelData
    {
        public uint highscore;
    }

    public GameObject envelopePrefab;
    public Vector3[] envelopePositions;

    private LevelData levelData;

    private void Awake()
    {
        string path = Path.Join(Application.persistentDataPath, "SaveData", "LevelData");
        levelData = new();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            levelData = JsonUtility.FromJson<LevelData>(json);
        }
    }

    private void Start()
    {
        SpawnEnvelopes(envelopePositions);
    }

    private void Update()
    {
        /*
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            GameObject nearestEnvelope = LocateNearestEnvelope(player);
            Debug.DrawLine(player.transform.position, nearestEnvelope.transform.position);
        }
        */
    }

    public bool UpdateHighScore(uint score)
    {
        if (score > levelData.highscore)
        {
            levelData.highscore = score;
            string path = Path.Join(Application.persistentDataPath, "SaveData");
            string contents = JsonUtility.ToJson(levelData);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(Path.Join(path, "LevelData"), contents);
            return true;
        }
        return false;
    }

    private void SpawnEnvelopes(Vector3[] positions)
    {
        int numEnvelopes = (int)(positions.Length * 0.75);
        ShufflePositions(positions);
        PopulateEnvelopes(positions, numEnvelopes);
    }

    public GameObject LocateNearestEnvelope(GameObject obj)
    {
        GameObject closestEnvelope = null;
        float threshold = Mathf.Infinity;
        foreach (GameObject envelope in GameObject.FindGameObjectsWithTag("Envelope"))
        {
            float distance = Vector3.Distance(obj.transform.position, envelope.transform.position);
            if (distance < threshold)
            {
                closestEnvelope = envelope;
                threshold = distance;
            }
        }
        return closestEnvelope;
    }

    private void PopulateEnvelopes(Vector3[] positions, int count)
    {
        if (count <= positions.Length)
        {
            int i = 0;
            while (i < count)
            {
                Instantiate(envelopePrefab, positions[i++], Quaternion.Euler(0, 0, 90));
            }
        }
    }

    private void ShufflePositions(Vector3[] positions)
    {
        int i = 0;
        while (i < positions.Length - 1)
        {
            int r = Random.Range(0, positions.Length);
            (positions[r], positions[i]) = (positions[i++], positions[r]);
        }
    }
}