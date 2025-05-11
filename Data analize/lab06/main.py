import os
import sys
import ffmpeg


def convert_mp4_to_mp3(input_file, output_file):
    try:
        ffmpeg.input(input_file).output(output_file, format='mp3', audio_bitrate='192k').run(overwrite_output=True)
        print(f'Конвертація завершена: {output_file}')
    except ffmpeg.Error as e:
        print(f'Помилка під час конвертації: {e}')


if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Використання: python script.py input.mp4 [output.mp3]")
        sys.exit(1)

    input_path = sys.argv[1]
    output_path = sys.argv[2] if len(sys.argv) > 2 else os.path.splitext(input_path)[0] + ".mp3"

    convert_mp4_to_mp3(input_path, output_path)
