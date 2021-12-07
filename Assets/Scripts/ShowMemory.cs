using System.Text;
using Unity.Profiling;
using UnityEngine;

// https://docs.unity3d.com/Manual/ProfilerMemory.html

public class ShowMemory : MonoBehaviour
{
    string Memory;
    ProfilerRecorder totalReservedMemoryRecorder;
    ProfilerRecorder gcReservedMemoryRecorder;
    ProfilerRecorder systemUsedMemoryRecorder;

    void OnEnable()
    {
        totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
        gcReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        systemUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
    }

    void OnDisable()
    {
        totalReservedMemoryRecorder.Dispose();
        gcReservedMemoryRecorder.Dispose();
        systemUsedMemoryRecorder.Dispose();
    }

    void Update()
    {
        var sb = new StringBuilder(800);

        if (totalReservedMemoryRecorder.Valid) {
            sb.AppendLine($"Total Reserved Memory: {totalReservedMemoryRecorder.LastValue}");
        }    
        if (gcReservedMemoryRecorder.Valid){
            sb.AppendLine($"GC Reserved Memory: {gcReservedMemoryRecorder.LastValue}");
        }
            if (systemUsedMemoryRecorder.Valid){
                sb.AppendLine($"System Used Memory: {systemUsedMemoryRecorder.LastValue}");
            }
             
        Memory = sb.ToString();
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 250, 50), Memory);
    }
}