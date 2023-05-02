using System.IO;
using UnityEngine;

public class EnvelopeManager : MonoBehaviour
{
    [System.Serializable]
    private class EnvelopePosition
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    private class LevelData
    {
        public EnvelopePosition[] envelopePositions;
        public uint highestScore;
    }

    public GameObject envelopePrefab;
    public string levelDataFilename;

    private string levelDataPath;
    private LevelData levelData;

    private void Awake()
    {
        levelDataPath = Path.Combine(Application.dataPath, "Resources", levelDataFilename);
        string levelDataJSON = File.ReadAllText(levelDataPath);
        levelData = JsonUtility.FromJson<LevelData>(levelDataJSON);
    }

    private void Start()
    {
        SpawnEnvelopes(levelData.envelopePositions);
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
        if (score > levelData.highestScore)
        {
            levelData.highestScore = score;
            string contents = JsonUtility.ToJson(levelData);
            File.WriteAllText(levelDataPath, contents);
            return true;
        }
        return false;
    }

    private void SpawnEnvelopes(EnvelopePosition[] positions)
    {
        int numEnvelopes = (int)(positions.Length * 0.75);
        ShufflePositions(positions);
        PopulateEnvelopes(positions, numEnvelopes);
    }

    private GameObject LocateNearestEnvelope(GameObject obj)
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

    private void PopulateEnvelopes(EnvelopePosition[] positions, int count)
    {
        if (count <= positions.Length)
        {
            int i = 0;
            while (i < count)
            {
                EnvelopePosition position = positions[i++];
                Vector3 envelopeVector = new(position.x, position.y, position.z);
                Instantiate(envelopePrefab, envelopeVector, Quaternion.Euler(0, 0, 90));
            }
        }
    }

    private void ShufflePositions(EnvelopePosition[] positions)
    {
        int i = 0;
        while (i < positions.Length - 1)
        {
            int r = Random.Range(0, positions.Length);
            (positions[r], positions[i]) = (positions[i++], positions[r]);
        }
    }
}