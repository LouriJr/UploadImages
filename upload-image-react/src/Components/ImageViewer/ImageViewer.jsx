import React from 'react'
import styles from "./ImageViewer.module.css";

export default function ImageViewer({ image }) {
    return (
        <div className={styles.imageViewer}>
            <span>{image.name}</span>
            <img src={image.url} alt={image.name}/>
        </div>
    )
}
