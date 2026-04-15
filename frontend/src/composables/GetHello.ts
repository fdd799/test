import { ref, onMounted } from 'vue'
import axios from 'axios'
import { apiUrl } from './ApiUrl'

interface HelloResponseDto {
    message: string
}

export const useGetHello = () => {
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