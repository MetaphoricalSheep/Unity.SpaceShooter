using UnityEngine;
using System.Collections;

namespace MetaphoricalSheep.UnityTools.Audio
{
    public static class AudioSourceExtentions
    {
        public static void FadeOut(this AudioSource source, float duration, float volume = 0.0f)
        {
            source.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(source, duration, volume));
        }

        public static void Fade(this AudioSource source, float duration, float volume = 0.0f)
        {
            source.GetComponent<MonoBehaviour>().StartCoroutine(FadeCore(source, duration, volume));
        }

        public static void FadeIn(this AudioSource source, float duration, float volume = 1f)
        {
            source.GetComponent<MonoBehaviour>().StartCoroutine(FadeInCore(source, duration, volume));
        }

        public static void EasePitch(this AudioSource source, float duration, float pitch)
        {
            source.GetComponent<MonoBehaviour>().StartCoroutine(EasePitchCore(source, duration, pitch));
        }

        private static IEnumerator FadeOutCore(AudioSource source, float duration, float volume)
        {
            float startVolume = source.volume;

            yield return FadeCore(source, duration, volume);

            source.Stop();
            source.volume = startVolume;
        }

        private static IEnumerator FadeCore(AudioSource source, float duration, float volume)
        {
            float startVolume = source.volume;
            float startTime = Time.unscaledTime;

            while ((Time.unscaledTime - startTime) < duration)
            {
                source.volume = Mathf.Lerp(startVolume, volume, (Time.unscaledTime - startTime) / duration);

                yield return null;
            }

            source.volume = volume;
        }

        private static IEnumerator FadeInCore(AudioSource source, float duration, float volume)
        {
            float startVolume = source.volume;
            float startTime = Time.unscaledTime;

            while ((Time.unscaledTime - startTime) < duration)
            {
                source.volume = Mathf.Lerp(startVolume, volume, (Time.unscaledTime - startTime) / duration);

                yield return null;
            }

            source.volume = volume;
        }

        private static IEnumerator EasePitchCore(AudioSource source, float duration, float pitch)
        {
            float startPitch = source.pitch;
            float startTime = Time.unscaledTime;

            while ((Time.unscaledTime - startTime) < duration)
            {
                source.pitch = Mathf.Lerp(startPitch, pitch, (Time.unscaledTime - startTime) / duration);

                yield return null;
            }

            source.pitch = pitch;
        }
    }
}
