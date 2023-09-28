import axios from 'axios'
import React, { useEffect, useState } from 'react'
import ImageViewer from '../ImageViewer/ImageViewer';
import styles from "./ImageList.module.css";

export default function ImageList() {
    const [images, setImages] = useState([])

    useEffect(()=>{
        fetchImages();
    }, []);

    async function fetchImages() {
        const response = await axios.get("https://localhost:44363/api/image");
        setImages(response.data);
    }
    return (
        <div className={styles.imageContainer}>
            {
                images.map(image => (
                    <ImageViewer image={image}></ImageViewer>
                ))
            }
        </div>
    )
}
