<template>
  <div class="container">
    <a-form :layout="'vertical'" :rules="rules">
      <a-form-item>
        <div>
          <h1>验证电子邮件地址</h1>
          <div>
            <span>为验证您的email，我们向</span><br />
            {{ localUser.email }}发送了一个代码<router-link
              :to="{ name: 'register' }"
              >更改</router-link
            >
          </div>
        </div>
      </a-form-item>
      <a-form-item label="请输入验证码" name="vertifyCode">
        <a-input v-model:value="vertifyCode"> </a-input>
      </a-form-item>
      <a-form-item>
        <a-button @click="vertifyCodeAndCreateAccount()" type="primary" block
          >验证</a-button
        >
      </a-form-item>
      <a-form-item :style="{ 'text-align': 'center' }">
        <a-button type="link" @click="sendActivateCode()"
          >重新发送验证码</a-button
        >
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
import { useRoute, useRouter } from "vue-router";
import { register, emailVertify } from "../../api/login";
import { ref,toRefs } from "vue";
export default {
  props: ["user"],
  setup(props) {
    console.log(toRefs(props.user))
    const route = useRoute();
    const router = useRouter();
    const localUser = route.params;
    console.log(route.params);
    const vertifyCode = ref("");
    const sendActivateCode = async () => {
      await emailVertify();
    };
    const vertifyCodeAndCreateAccount = () => {
      if (localUser.vertifyCode === vertifyCode.value) {
        register(localUser)
          .then(() => {
            router.push({ name: "login" });
          })
          .catch((error) => console.log(error));
      }
    };
    const rules = {
      vertifyCode: { required: true, message: "请输入验证码", trigger: "blur" },
    };
    return {
      localUser,
      sendActivateCode,
      vertifyCode,
      vertifyCodeAndCreateAccount,
      rules,
    };
  },
};
</script>

<style lang="less" scoped>
.container {
  width: 350px;
  margin: 20px auto;
  border: 1px solid;
  padding: 20px;
  text-align: left;
  .logo {
    width: 30px;
    height: 30px;
  }
}
</style>