import { ref, onMounted } from 'vue'
import axios from 'axios'

interface HelloResponseDto {
    message: string
}

export const useGetHello = () => {
    const apiUrl = import.meta.env.VITE_API_URL

    const helloResponse = ref<HelloResponseDto>({
        message: ''
    })

    const getHello = async () => {
        const res = await axios.get(`${apiUrl}/hello`)
        helloResponse.value = res.data
    }

    onMounted(getHello)

    return { helloResponse }
}