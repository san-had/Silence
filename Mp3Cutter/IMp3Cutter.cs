﻿using Mp3CutterService.Dto;

namespace Mp3CutterService
{
    public interface IMp3Cutter
    {
        Mp3OutputDto ExecuteCut(Mp3InputDto mp3InputDto);
    }
}