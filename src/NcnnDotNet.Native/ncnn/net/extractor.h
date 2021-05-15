#ifndef _CPP_NET_EXTRACTOR_H_
#define _CPP_NET_EXTRACTOR_H_

#include "../export.h"
#include <net.h>
#include "../shared.h"

DLLEXPORT void net_Extractor_delete(ncnn::Extractor* extractor)
{
    if (extractor != nullptr) delete extractor;
}

DLLEXPORT int net_Extractor_set_light_mode(ncnn::Extractor* extractor,
                                            const bool enable)
{
    int32_t error = ERR_OK;

    extractor->set_light_mode(enable);

    return error;
}

DLLEXPORT int net_Extractor_set_num_threads(ncnn::Extractor* extractor,
                                            const int32_t num_threads)
{
    int32_t error = ERR_OK;

    extractor->set_num_threads(num_threads);

    return error;
}

DLLEXPORT int net_Extractor_input(ncnn::Extractor* extractor,
                                  const char* blob_name,
                                  const int32_t blob_name_len,
                                  ncnn::Mat* in)
{
    int32_t error = ERR_OK;

    std::string name(blob_name, blob_name_len);
    auto& mat_in = *in;
    const auto ret = extractor->input(name.c_str(), mat_in);
    if (ret != 0)
        return ERR_GENERAL_ERROR;

    return error;
}

DLLEXPORT int net_Extractor_extract(ncnn::Extractor* extractor,
                                    const char* blob_name,
                                    const int32_t blob_name_len,
                                    ncnn::Mat* feat)
{
    int32_t error = ERR_OK;

    std::string name(blob_name, blob_name_len);
    auto& mat_feat = *feat;
    const auto ret = extractor->extract(name.c_str(), mat_feat);
    if (ret != 0)
        return ERR_GENERAL_ERROR;

    return error;
}

#endif