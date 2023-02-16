import { convertToBase64 } from "./convertors.js";

export async function handleUploadFiles (
    files,
    setUploadedFiles,
    setFileLimit,
    uploadedFiles
) {
    files = Array.from(files);
    const maxValue = 6;
    const uploaded = [...uploadedFiles];
    let limitExceeded = false;

    for (const file of files) {
        if (uploaded.findIndex((f) => f.name === file.name) === -1) {
            const base64 = await convertToBase64(file);
            uploaded.push({ name: file.name, base64 });
            if (uploaded.length === maxValue) setFileLimit(true);
            if (uploaded.length > maxValue) {
                setFileLimit(false);
                limitExceeded = true;
            }
        }
    }

    if (!limitExceeded) {
        setUploadedFiles(uploaded);
    }
}
