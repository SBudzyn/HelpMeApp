import { convertToBase64 } from "./convertors.js";
export async function handleUploadFiles (
    files,
    setUploadedFiles,
    setFileLimit,
    uploadedFiles
) {
    files = Array.from(files);
    const uploaded = [...uploadedFiles];
    let limitExceeded = false;
    for (const file of files) {
        if (uploaded.findIndex((f) => f.name === file.name) === -1) {
            const base64 = await convertToBase64(file);
            uploaded.push({ name: file.name, base64: base64 });
            if (uploaded.length === 6) setFileLimit(true);
            if (uploaded.length > 6) {
                setFileLimit(false);
                limitExceeded = true;
            }
        }
    }
    if (!limitExceeded) setUploadedFiles(uploaded);
}
