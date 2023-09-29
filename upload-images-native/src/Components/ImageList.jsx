import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { Image, Text, View } from 'react-native';

export default function ImageList() {
    const [images, setImages] = useState([])

    useEffect(() => {
        fetchImages();
    }, []);

    async function fetchImages() {
        const response = await axios.get("https://localhost:44363/api/image");
        console.log(response.data);
        setImages(response.data);
    }
    return (
        <View>
            {
                images.map((image, key) => (
                    <View>
                        <Text>{image.name}</Text>
                        <Image key={key} source={{ uri: image.url }} style={{ width: 200, height: 200 }} />
                    </View>
                ))
            }
        </View>
    )
}
